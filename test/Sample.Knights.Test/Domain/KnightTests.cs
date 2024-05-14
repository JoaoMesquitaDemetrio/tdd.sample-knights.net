using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Knights.Core.Domain.Entities.Knights;
using Sample.Knights.Core.Domain.Enums;
using Sample.Knights.Test.Shared.Fixtures.Entities;
using Sample.Utils.Extensions;

namespace Sample.Knights.Test.Domain;

public class KnightTests
{
    public KnightTests() { }
    
    public sealed class ValidateAge : KnightTests
    {
        public ValidateAge() : base() { }
        
        [Fact]
        public void ShouldReturnTrueWhenKnightHasntCelebratedCongrats()
        {
            // Arrange
            var knight = KnightFixture.CreateKnight();
            knight.Birthday = DateTime.Now.AddYears(-19);
            knight.Birthday = knight.Birthday.AddDays(1);
            
            // Act
            var result = knight.GetAge();
            
            // Assert
            Assert.Equal(18, result);
        }
        
        [Fact]
        public void ShouldReturnTrueWhenKnightNotRegisterBirthday()
        {
            // Arrange
            var knight = KnightFixture.CreateKnight();
            knight.Birthday = default;
            
            // Act
            var result = knight.GetAge();
            
            // Assert
            Assert.Equal(0, result);
        }

        [Theory]
        [MemberData(nameof(WithMultipleAgesTestData))]
        public void ShouldReturnTrueToCompareMinimumAge(Knight knight, bool hasMinimal)
        {
            // Act
            var result = knight.HasMinimumAge();

            // Assert
            Assert.Equal(hasMinimal, result);
        }
        
        public static IEnumerable<object[]> WithMultipleAgesTestData()
        {
            var testData = new List<object[]>();

            var knightAdult = KnightFixture.CreateKnight();
            knightAdult.Birthday = DateTime.Now.AddYears(-19);
            knightAdult.Birthday = knightAdult.Birthday.AddDays(1);
            
            var knightChild = KnightFixture.CreateKnight();
            knightChild.Birthday = DateTime.Now.AddYears(-7);
            knightChild.Birthday = knightChild.Birthday.AddDays(1);

            var knightChild2 = KnightFixture.CreateKnight();
            knightChild2.Birthday = DateTime.Now.AddYears(-7);
            
            testData.Add([ knightAdult, true ]);
            testData.Add([ knightChild, false ]);
            testData.Add([ knightChild2, true ]);

            return testData;
        } 
    }

    public sealed class ValidateWeapon : KnightTests 
    {
        public ValidateWeapon() : base() { }
        
        [Fact]
        public void ShouldReturnTrueWhenKnightHasWeaponEquipped()
        {
            // Arrange
            var weapons = new List<Weapon> 
            { 
                WeaponFixture.CreateWeapon(TypeAttribute.DEXTERITY),
                WeaponFixture.CreateWeapon(TypeAttribute.STRENGTH, true),
                WeaponFixture.CreateWeapon(TypeAttribute.WISDOM)
            };

            var knight = KnightFixture.CreateKnight(TypeAttribute.STRENGTH,  weapons);
                        
            // Act
            var result = knight.HasWeaponEquipped();
            
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnModZeroWhenKnightHasntWeaponEquipped()
        {
            // Arrange
            var weapons = new List<Weapon> 
            { 
                WeaponFixture.CreateWeapon(TypeAttribute.DEXTERITY),
                WeaponFixture.CreateWeapon(TypeAttribute.STRENGTH),
                WeaponFixture.CreateWeapon(TypeAttribute.WISDOM)
            };

            var knight = KnightFixture.CreateKnight(TypeAttribute.STRENGTH, weapons);
                        
            // Act
            var result = knight.GetModFromEquippedWeapon();
            
            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void ShouldReturnModZeroWhenKnightHasntWeapons()
        {
            // Arrange
            var weapons = default(IEnumerable<Weapon>);
            var knight = KnightFixture.CreateKnight(TypeAttribute.STRENGTH, weapons);
                        
            // Act
            var result = knight.GetModFromEquippedWeapon();
            
            // Assert
            Assert.Equal(0, result);
        }
    }

    public sealed class ValidateAttributes : KnightTests 
    {
        public ValidateAttributes() : base() { }
        
        [Fact]
        public void ShouldReturnTrueWhenCompareFieldsWithEnumerator()
        {
            // Arrange
            var AttributesFields = typeof(Attributes).GetProperties().Select(p => p.Name).ToList();
            var TypeAttributeFields = typeof(TypeAttribute).GetValues<TypeAttribute>();

            // Act
            var result = TypeAttributeFields
                .Select(x => x.GetDescription())
                .All(x => AttributesFields.Contains(x));    
            
            // Assert
            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(WithMultipleModAttributesTestData))]
        public void ShouldReturnModValueWhenKnightHasntKeyAttribute(TypeAttribute typeAttribute, Attributes attributes, int mod)
        {
            // Act
            var result = attributes.GetModFromAttribute(typeAttribute);
            
            // Assert
            Assert.Equal(mod, result);
        }
        
         public static IEnumerable<object[]> WithMultipleModAttributesTestData()
        {
            var testData = new List<object[]>();

            var attributes = AttributesFixture.CreateAtributtes();
            attributes.Strength = 6;
            attributes.Dexterity = 10;
            attributes.Constitution = 11;
            attributes.Intelligence = 15;
            attributes.Wisdom = 18;
            attributes.Charisma = 19;

            testData.Add([ TypeAttribute.STRENGTH, attributes, -2 ]);
            testData.Add([ TypeAttribute.DEXTERITY, attributes, -1 ]);
            testData.Add([ TypeAttribute.CONSTITUTION, attributes, 0 ]);
            testData.Add([ TypeAttribute.INTELLIGENCE, attributes, 1 ]);
            testData.Add([ TypeAttribute.WISDOM, attributes, 2 ]);
            testData.Add([ TypeAttribute.CHARISMA, attributes, 3 ]);
            
            return testData;
        }
    } 

    public sealed class ValidateKnight : KnightTests 
    {
        public ValidateKnight() : base() { }
        
        [Theory]
        [MemberData(nameof(WithMultipleAgesTestData))]
        public void ShouldReturnExpectedExperince(Knight knight, int expectedExperience)
        {
            // Act
            var result = knight.GetExperience();
            
            // Assert
            Assert.Equal(expectedExperience, result);
        }
        
        [Theory]
        [MemberData(nameof(WithMultipleModTestData))]
        public void ShouldReturnExpectedAttack(Knight knight, int expectedAttack)
        {
            // Act
            var result = knight.GetAttack();
            
            // Assert
            Assert.Equal(expectedAttack, result);
        }
        
        public static IEnumerable<object[]> WithMultipleAgesTestData()
        {
            var testData = new List<object[]>();

            var knightAdult = KnightFixture.CreateKnight();
            knightAdult.Birthday = DateTime.Now.AddYears(-19);
            
            var knightChild = KnightFixture.CreateKnight();
            knightChild.Birthday = DateTime.Now.AddYears(-6);

            testData.Add([ knightAdult, 1060 ]);
            testData.Add([ knightChild, 0 ]);

            return testData;
        }

        public static IEnumerable<object[]> WithMultipleModTestData()
        {
            var testData = new List<object[]>();

            var currentWeapon = WeaponFixture.CreateWeapon(TypeAttribute.STRENGTH, true);
            currentWeapon.Mod = 3;

            var weapons = new List<Weapon> 
            { 
                WeaponFixture.CreateWeapon(TypeAttribute.DEXTERITY),
                WeaponFixture.CreateWeapon(TypeAttribute.WISDOM),
                currentWeapon
            };

            var knightAdult = KnightFixture.CreateKnight(TypeAttribute.STRENGTH,  weapons);
            knightAdult.Attributes.Strength = 20;
            
            var knightChild = KnightFixture.CreateKnight(TypeAttribute.CHARISMA);
            knightChild.Attributes.Charisma = 2;

            testData.Add([ knightAdult, 16 ]);
            testData.Add([ knightChild, 8 ]);

            return testData;
        }
    }
}

