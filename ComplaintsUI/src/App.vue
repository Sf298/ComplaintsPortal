<script setup>
import { watch } from 'vue';
import { RouterLink, RouterView, useRoute, useRouter } from 'vue-router'
import { currentRole, logout } from "./utils/login-manager"
import LoginPage from './views/LoginPage.vue';

const route = useRoute();
const router = useRouter();

// ensure that if an admin logs out from an admin-page and a user logs in, they are redirected to the home page
watch(currentRole, (newValue, oldValue) => {
  if (newValue && route.meta.allowedRoles && !route.meta.allowedRoles.includes(newValue)) {
    router.push({ path: '/' })
  }
});
</script>

<template>
  <template v-if="currentRole">
    <nav>
      <router-link to="/">Home</router-link>
      <router-link v-if="currentRole == 'admin'" to="/complaint/list">List</router-link>
      <router-link to="/complaint/create">Create</router-link>
      <button class="logout-button" @click="logout">Logout</button>
    </nav>
    <RouterView />
  </template>
  <template v-else>
    <LoginPage />
  </template>
</template>

<style scoped>
nav {
  width: calc(100% - 19px);
  background-color: #DDDDDD;
  padding: 10px;
  display: flex;
  gap: 20px;
}

nav a {
  font-size: x-large;
  font-weight: 600;
  text-decoration: none;
  user-select: none;
}

.router-link-active {
  color: rgb(0, 0, 187);
  text-decoration: underline;
}

.logout-button {
  margin-left: auto;
}
</style>