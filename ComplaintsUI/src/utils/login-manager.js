import { ref } from "vue";

window.currentRole = ref();
export const currentRole = window.currentRole;

export function login(username, password) {
    if (username != "user" && username != "admin") {
        return "User not found";
    }
    window.currentRole.value = username;
}
export function logout() {
    window.currentRole.value = null;
}