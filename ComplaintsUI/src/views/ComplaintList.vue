<script setup>
import { ref } from "vue";
import Complaints from "../utils/complaints-api"

var allComplaints = ref();

// update the allComplaints array. In turn updates the displayed list
async function updateComplaints() {
  try {
    const list = await Complaints.getAll()
    allComplaints.value = list;
  } catch(error) {
    allComplaints.value = error.message
  }
}
updateComplaints();

// request the api deletes a complaint, then refresh the list
async function deleteComplaint(id) {
  await Complaints.delete(id)
  await updateComplaints();
}

// format a date string into something more readable
function formatDate(dateString) {
  const date = new Date(dateString);
  return date.toLocaleString(); 
}
</script>

<template>
  <main>
    <div class="table-wrapper">
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Complaint Type</th>
            <th>Created By</th>
            <th>Created Date</th>
            <th>Message</th>
            <th>Status</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          <tr v-if="Array.isArray(allComplaints)" v-for="complaint in allComplaints" :key="complaint.id">
            <td>{{ complaint.id }}</td>
            <td>{{ complaint.complaintType }}</td>
            <td>{{ complaint.createdBy }}</td>
            <td>{{ formatDate(complaint.createdDate) }}</td>
            <td>{{ complaint.message }}</td>
            <td>{{ complaint.status }}</td>
            <td>
              <router-link :to="'/complaint/list/'+complaint.id"><button>Edit</button></router-link>
              <button @click="() => deleteComplaint(complaint.id)">Delete</button>
            </td>
          </tr>
        </tbody>
      </table>
      <h3 v-if="!Array.isArray(allComplaints)" class="error message">{{ allComplaints }}</h3>
      <h3 v-if="!allComplaints" class="message">Loading...</h3>
    </div>
  </main>
</template>

<style scoped>
.table-wrapper {
  margin: 50px auto 0 auto;
  width: fit-content;
  font-size: larger;
  max-width: 60%;
}
table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 20px;
}

table th, table td {
  border: 1px solid #ddd;
  padding: 8px;
  text-align: left;
  overflow-wrap: break-word;  
}

table th {
  background-color: #f2f2f2;
}

.message {
  width: 100%;
  text-align: center;
}
.error {
  color: red;
}
button {
  margin: 4px;
}
</style>../utils/complaints