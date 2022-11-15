import api from "../api/config";

const baseUrl = "Dashboard";

export function getGraphDataTasksExecuted() {
  return api.get(`${baseUrl}/graphDataTasksExecuted`);
}

export function getGraphDataTagTasksExecuted() {
  return api.get(`${baseUrl}/graphDataTagTasksExecuted`);
}

