<script lang="ts">
import { obterHerois } from '@/http/index';
import type IKnight from "@/interface/IKnight";

export default {
    data() {
        return {
            cavalheiros: [] as IKnight[]
        }
    },

    async created() {
        this.cavalheiros = await obterHerois();
    }
}
</script>

<template>
    <Section class="selecionar-ingredientes">
        <h1 class="cabecalho titulo-ingredientes">
            Sua Lista de Cavaleiros
        </h1>

        <table>
            <thead>
                <tr>
                    <th>Nome</th>
                    <th>Idade</th>
                    <th>Armas</th>
                    <th>Atributo</th>
                    <th>Ataque</th>
                    <th>Experiência</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="cavalheiro in cavalheiros" :key="cavalheiro.name">
                    <td>{{ cavalheiro.name }}</td>
                    <td>{{ cavalheiro.age }}</td>
                    <td>{{ cavalheiro.weapons }}</td>
                    <td>{{ cavalheiro.attribute_description }}</td>
                    <td>{{ cavalheiro.attack }}</td>
                    <td>{{ cavalheiro.experience }}</td>
                </tr>
            </tbody>
        </table>
        
    </Section>
</template>

<style scoped>
.selecionar-ingredientes {
    display: flex;
    flex-direction: column;
    align-items: center;
}

.titulo-ingredientes {
    color: var(--verde-medio, #3D6D4A);
    display: block;
    margin-bottom: 1.5rem;
}

.instrucoes {
    margin-bottom: 2rem;
}

.categorias {
    margin-bottom: 1rem;
    display: flex;
    justify-content: center;
    gap: 1.5rem;
    flex-wrap: wrap;
}

.dica {
    align-self: flex-start;
    margin-bottom: 3.5rem;
}

@media only screen and (max-width: 767px) {
    .dica {
        margin-bottom: 2.5rem;
    }
}

body {
    font-family: Arial, sans-serif;
}

table {
    width: 1000px;
    border-collapse: collapse;
}

th,
td {
    border: 1px solid var(--verde-medio, #3D6D4A);;
    padding: 10px;
    text-align: center;
}

th {
    background-color: var(--verde-medio, #3D6D4A);;
    color: white;
}

tr:nth-child(even) {
    background-color: #f2f2f2;
}

tr:hover {
    background-color: lightgray;
}

caption {
    caption-side: top;
    font-size: 1.0em;
    margin: 10px 0;
    color: slategray;
}
</style>