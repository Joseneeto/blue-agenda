import { createRouter, createWebHistory } from 'vue-router'
import AgendaView from '../views/AgendaView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: AgendaView
    },   
  ]
})

export default router
