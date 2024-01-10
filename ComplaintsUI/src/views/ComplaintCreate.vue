
<script setup>
import Complaints from "../utils/complaints-api"
import { ref } from 'vue';

const generateDefaultEntity = () => {
  return {
    complaintType: "",
    message: "",
  }
}
const entity = ref(generateDefaultEntity());
const validationErrors = ref();

const saveChanges = async() => {
  try {
    const response = await Complaints.create(entity.value)
    if (response.status == 400) {
      const message = await response.json();
      validationErrors.value = message.errors;
      console.log("xxx", validationErrors.value)
      console.log("xxx1", validationErrors.value?.Message[0])
      return;
    }
    
    validationErrors.value = undefined;
    entity.value = generateDefaultEntity();
  } catch (error) {
    alert(error.message)
  }
};
</script>

<template>
  <div class="wrapper">
    <form @submit.prevent="saveChanges">

      <div class="form-group">
        <label>Complaint Type:</label>
        <span v-if="validationErrors?.ComplaintType" class="field-error-label">{{ validationErrors.ComplaintType[0] }}</span>
        <select v-model="entity.complaintType">
          <option value="quality">Quality</option>
          <option value="shipping">Shipping</option>
          <option value="billing">Billing</option>
        </select>
      </div>

      <div class="form-group">
        <label>Message:</label>
        <span v-if="validationErrors?.Message" class="field-error-label">{{ validationErrors.Message[0] }}</span>
        <textarea v-model="entity.message"></textarea>
      </div>

      <button type="submit">Save Changes</button>
    </form>
  </div>
</template>

<style scoped>
.wrapper {
  width: 50%;
  margin: 50px auto 0 auto;
}

</style>../utils/complaints