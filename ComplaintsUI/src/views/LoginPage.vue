
<script setup>
import { ref } from 'vue';
import { login } from "../utils/login-manager"

const username = ref("");
const password = ref("");
const loginErrorMessage = ref();

const loginCallback = () => {
    // user clicked login
    loginErrorMessage.value = login(username.value, password.value);
};
</script>

<template>
    <div class="login-container">
        <form @submit.prevent="loginCallback">
            <h2>Complaints Portal Login</h2>
            <div v-if="loginErrorMessage" class="field-error-label">{{ loginErrorMessage }}</div>
            <div class="form-group">
                <label for="username">Username:</label>
                <input type="text" id="username" v-model="username" required />
            </div>
            <div class="form-group">
                <label for="password">Password:</label>
                <input type="password" id="password" v-model="password" />
            </div>
            <button type="submit">Login</button>
        </form>
    </div>
</template>
  
<style scoped>
.login-container {
    max-width: 400px;
    margin: auto;
    margin-top: calc(50vh - 8%);
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 5px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

form {
    gap: 15px;
}

.field-error-label {
    margin: 0;
}
</style>
  