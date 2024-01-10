import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/complaint/list',
      name: 'list-complaints',
      component: () => import('../views/ComplaintList.vue'),
      meta: { allowedRoles: ["admin"] },
    },
    {
      path: '/complaint/list/:id',
      name: 'update-complaint',
      component: () => import('../views/ComplaintUpdate.vue'),
      meta: { allowedRoles: ["admin"] },
    },
    {
      path: '/complaint/create',
      name: 'create-complaint',
      component: () => import('../views/ComplaintCreate.vue'),
      meta: { allowedRoles: ["user", "admin"] },
    },
  ]
})

export default router
