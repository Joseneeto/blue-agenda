import router from './router'

import {compile, createApp} from 'vue'
import App from './App.vue'

import PrimeVue from 'primevue/config'  // import PrimeVue

// import CSS resources
import 'primevue/resources/primevue.min.css';            // core 
import 'primevue/resources/themes/saga-blue/theme.css';  // theme
import 'primeicons/primeicons.css';                      // icons
import '/node_modules/primeflex/primeflex.css';          // PrimeFlex


import Button from 'primevue/button';  // import Button component
import InputText from 'primevue/inputtext';
import InputMask from 'primevue/inputmask';
import DataTable from 'primevue/datatable';
import Dialog from 'primevue/dialog';
import Column from 'primevue/column';

const app = createApp(App); 

app.component("InputMask", InputMask);
app.component("Button", Button);
app.component("InputText", InputText);
app.component("DataTable", DataTable);
app.component("Dialog", Dialog);
app.component("Column", Column);

app.use(router);
app.use(PrimeVue); 

app.mount("#app");