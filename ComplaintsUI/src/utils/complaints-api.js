
var backendBaseUrl = import.meta.env.VUE_APP_BACKEND_BASE_URL
console.log("backendBaseUrl", import.meta.env.VUE_APP_BACKEND_BASE_URL)
console.log("backendBaseUrl", import.meta.env.BACKEND_BASE_URL)

var backendBaseUrl = "http://localhost:5265"

const Complaints = {
    getAll: async function() {
        const data = await fetch(backendBaseUrl+"/api/complaints");
        const json = await data.json();
        return json;
    },
    get: async function(id) {
        const data = await fetch(backendBaseUrl+"/api/complaints/"+id);
        const json = await data.json();
        return json;
    },
    create: async function(complaint) {
        const dto = {
            createdBy: complaint.createdBy,
            complaintType: complaint.complaintType,
            message: complaint.message,
        }
        const response = await fetch(backendBaseUrl+"/api/complaints", {
            method:"POST",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(dto),
        });
        return response;
    },
    update: async function(complaint) {
        const dto = {
            createdBy: complaint.createdBy,
            createdDate: complaint.createdDate,
            complaintType: complaint.complaintType,
            message: complaint.message,
            status: complaint.status,
        }
        const response =  await fetch(backendBaseUrl+"/api/complaints/"+complaint.id, {
            method:"PUT",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(dto),
        });
        return response;
    },
    delete: async function(id) {
        await fetch(backendBaseUrl+"/api/complaints/"+id, {method:"DELETE"});
    },
}

export default Complaints