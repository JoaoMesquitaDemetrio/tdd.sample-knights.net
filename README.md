# Knights Challenger

Antes de compilar o projeto, certifique-se que tenha instalado:
- [.NET Core SDK 8.0](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
- [Node.js](https://nodejs.org/en/)
- [Docker](https://www.docker.com/products/docker-desktop)


## Definindo infraestrutura para execução do projeto
### Criação da rede no docker
Esse comando precisa ser executado apenas uma vez, caso já possua a `knight-network` criada, pule para o próximo passo.  
Todos os containeres precisam ficar na mesma rede no docker para que possam trocar informações.  
Para isso, vamos criar uma rede chamada knight-network executando o comando abaixo:

```
$ docker network create knight-network
```

### Criação do MongoDB no docker

Esse comando precisa ser executado apenas uma vez, caso já possua o container do `MongoDB` com a rede `knight-network` vinculada, pule para o próximo passo.  
  
**Caso não possua, criação do container do MongoDB:**

```
docker run -d --name mongodb  --network knight-network \
    -e MONGO_INITDB_ROOT_USERNAME=admin \
    -e MONGO_INITDB_ROOT_PASSWORD=@Abc1234 \
	-p 27017:27017 \
    mongo
```

**Caso possua, vincular a rede `knight-network` ao MongoDB:**

```	
docker network connect knight-network mongodb
```

Com isso, toda a infraestutura necessária para rodar a aplicação está pronta.  
Para executar o projeto, é necessário que o container `mongodb` estejam rodando.

## Utilização do `docker-compose`:

Acesse a pasta raíz do projeto e execute o comando abaixo para subir a aplicação:
```
$ docker-compose -f docker-compose.build.yml up -d
```

## Consumindo a aplicação
O endereço padrão para acessar a api é: 
```	
http://localhost:5171/api
```
Para mais informações sobre os endpoints disponíveis, acesse a documentação da API em:
```
http://localhost:5171/swagger/index.html
```
Temos a opção para execução dos endpoints via Insomnia, com o aplicativo instalado basta acessar a pasta raiz do projeto e importar a coleção em:
```	
.api_manegament\insominia\knight_insomnia.json
```
O endereco padrão para acessar a aplicação é:
```
http://localhost:8080/
```
