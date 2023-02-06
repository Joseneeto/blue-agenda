<template>
    <div class="form-demo">
        <section>
            <div class="flex justify-content-center">
                <div class="card">
                    <form class="p-fluid">
                        <div class="field">
                            <div class="p-inputgroup">
                                <span class="p-inputgroup-addon">
                                <i class="pi pi-user"></i>
                                </span>
                                <InputText placeholder="Nome" v-model="name" required/>
                            </div>  
                        </div>
                        <div class="field">
                            <div class="p-inputgroup">
                                <span class="p-inputgroup-addon">
                                <i class="pi pi-envelope"></i>
                                </span>
                                <InputText placeholder="Email" v-model="email" v-validate="'required|email'"/>
                            </div>                           
                        </div>
                        <div class="field">
                            <div class="p-inputgroup">
                                <span class="p-inputgroup-addon">
                                <i class="pi pi-phone"></i>
                                </span>
                                <InputText placeholder="Telefone" v-model="phone" required/>
                            </div>  
                        </div>
                        <Button type="submit" label="Cadastrar" class="mt-2 p-button-info" v-on:click="cadastrar"></Button>
                        
                    </form>
                </div>
            </div>
        </section> 
    </div>
    <br>
    <div>
        <DataTable :value="contatos" responsiveLayout="scroll">
            <Column field="id" header="Id"></Column>
            <Column field="name" header="Nome"></Column>
            <Column field="email" header="Email"></Column>
            <Column field="phone" header="Telefone"></Column>
            <Column field="status" header="">
                <template #body="slotProps">
                    <Button icon="pi pi-pencil" class="p-button-rounded p-button-info mr-2" @click="openEdit(slotProps.data)"  />
                    <Button icon="pi pi-trash" class="p-button-rounded p-button-danger" @click="deleteAgenda(slotProps.data.id)" />
                </template>
            </Column>
            
        </DataTable>
    </div>
    <Dialog v-model:visible="displayBasic" :style="{width: '450px'}" header="Atualizar Cadastro" :modal="true" class="p-fluid">
        <div class="field">
            <div class="p-inputgroup">
                <span class="p-inputgroup-addon">
                <i class="pi pi-user"></i>
                </span>
                <InputText placeholder="Nome" v-model="agenda.name"/>
            </div>  
        </div>
        <div class="field">
            <div class="p-inputgroup">
                <span class="p-inputgroup-addon">
                <i class="pi pi-envelope"></i>
                </span>
                <InputText placeholder="Email" v-model="agenda.email"/>
            </div>                           
        </div>
        <div class="field">
            <div class="p-inputgroup">
                <span class="p-inputgroup-addon">
                <i class="pi pi-phone"></i>
                </span>
                <InputText placeholder="Telefone" v-model="agenda.phone"/>
            </div>  
        </div>
        <template #footer>
            <Button label="Sair" icon="pi pi-times"  @click="closeEdit" autofocus class="p-button-text"/>
            <Button label="Salvar" icon="pi pi-check" @click="updateAgenda(agenda.id), closeEdit" />
        </template>
    </Dialog>    
   
</template>

<script>
import axios from 'axios';
export default {
    name: "Agenda",
    data()
    {
        return {
            contatos: [],
            id: '',
            name: '',
            email: '',
            phone: '',            
            displayBasic: false
        }
    },    
    async mounted()
    {     
        this.listar()
    },
    methods:{
        async listar()
        {
            let result = await axios.get("https://localhost:7294/api/Contato");
            this.contatos = result.data;
        },
        async cadastrar()
        {
            if(!this.name || !this.email || !this.phone){
                alert("Por favor, preencha todos os campos!");
                return;
            }
            console.warn(this.contatos)
            const result = await axios.post("https://localhost:7294/api/Contato/cadastrar",{
            name:this.name,
            email:this.email,
            phone:this.phone,
            });                       
        }, 
        openEdit(agenda) {
            this.displayBasic = true;
            this.agenda = {...agenda};           
        },
        closeEdit() {
            this.displayBasic = false;
        },
        async deleteAgenda(id)
        {            
            let result = await axios.delete('https://localhost:7294/api/Contato/remover/'+id);
            console.warn(result);
            if(result.status==200)
                this.listar()            
        },  
        async updateAgenda(id)
        {            
            const result = await axios.put('https://localhost:7294/api/Contato/alterar/'+id,{
            id: this.agenda.id,
            name:this.agenda.name,
            email:this.agenda.email,
            phone:this.agenda.phone,
            });   
            console.warn(result);
            if(result.status==200)
                this.displayBasic = false;
                this.listar()            
        }
    },       
}
</script>

<style lang="scss" scoped>
.form-demo {
    .card {
        min-width: 450px;
    } form {
        margin-top: 2rem;
    }
    .field {
        margin-bottom: 1.5rem;
    }

    @media screen and (max-width: 960px) {
        .card {
            width: 80%;
        }
    }
}
</style>