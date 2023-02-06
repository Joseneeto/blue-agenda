<template>    
    <header>
        <div class="blue-logo-container">
            <img src='/img/logo.png' alt="logo.png" />
            <h1>Agenda</h1>
        </div>
    </header >
</template>  

<script>
   export default{
       name: 'Header',    
   }
</script>

<style>


header {
    background: linear-gradient(180deg, #3f6097 95%, #fff 100%);
    height: 220px;
    display: flex;
    align-items: center;
    justify-content: center;
}

.blue-logo-container {
    display: flex;
    flex-direction: column;
    align-items: center;
}

.blue-logo-container img {
    width: 235px;
}

.blue-logo-container h1 {
    margin-top: 15px;
    font-size: 24px;
    color: #fff;
}

.blue-logo-container p {
    font-size: 14px;
    font-weight: 300;
}

</style>