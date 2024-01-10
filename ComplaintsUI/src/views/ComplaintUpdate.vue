
<script setup>
import Complaints from "../utils/complaints-api"
import { ref, onMounted } from 'vue';
import { useRoute, useRouter  } from 'vue-router';
import VueDatePicker from '@vuepic/vue-datepicker';

const route = useRoute();
const router = useRouter();
const entity = ref();
const validationErrors = ref();

onMounted(async () => {
  try {
    entity.value = await Complaints.get(route.params.id);
  } catch(error) {
    entity.value = error.message
  }
});

const saveChanges = async() => {
  const response = await Complaints.update(entity.value)
  if (response.status == 400) {
    const message = await response.json();
    validationErrors.value = message.errors;
    console.log("xxx", JSON.stringify(validationErrors.value))
    console.log("xxx1", validationErrors.value?.Message[0])
    return;
  }

  validationErrors.value = undefined;
  router.go(-1);
};

</script>

<template>
  <div class="wrapper">
    <h3 v-if="!entity" class="message">Loading</h3>
    <h3 v-else-if="typeof entity === 'string'" class="error message">{{ entity }}</h3>
    <form v-else @submit.prevent="saveChanges">
      
      <div class="form-group">
        <label>ID:</label>
        <input v-model="entity.id" disabled />
      </div>

      <div class="form-group">
        <label>Created By:</label>
        <span v-if="validationErrors?.CreatedBy" class="field-error-label">{{ validationErrors.CreatedBy[0] }}</span>
        <input v-model="entity.createdBy" />
      </div>

      <div class="form-group">
        <label>Created Date:</label>
        <span v-if="validationErrors?.CreatedDate" class="field-error-label">{{ validationErrors.CreatedDate[0] }}</span>
        <VueDatePicker v-model="entity.createdDate"></VueDatePicker>
      </div>

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

      <div class="form-group">
        <label>Status:</label>
        <span v-if="validationErrors?.Status" class="field-error-label">{{ validationErrors.Status[0] }}</span>
        <select v-model="entity.status">
          <option value="pending">Pending</option>
          <option value="resolved">Resolved</option>
          <option value="dismissed">Dismissed</option>
        </select>
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

.message {
  width: 100%;
  text-align: center;
  font-size: x-large;
  margin-top: 100px;
}

.error {
  color: red;
}
</style>../utils/complaints