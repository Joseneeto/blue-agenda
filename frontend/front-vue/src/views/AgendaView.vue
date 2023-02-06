<template>
    
    <header>
        <Header />
    </header> 
    
    <body>
        <Agenda />
    </body>
         
  
</template>  

<script>
import Header from '../components/Header.vue';
import Agenda from '../components/Agenda.vue';
    export default{
        name: 'AgendaView',
        components:{
    Header,
    Agenda
    }            
}
</script>