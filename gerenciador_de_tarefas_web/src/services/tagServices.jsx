import api from "../api/config";

const baseUrl = "Tag";

export function save(obj) {
  return obj.id > 0
    ? api.put(`${baseUrl}/${obj.id}`, obj)
    : api.post(baseUrl, obj);
}

export function getById(id) {
  return api.get(`${baseUrl}/${id}`);
}

export function getAll() {
  return api.get(baseUrl);
}

export function deleteTag(obj) {
  return api.put(`${baseUrl}/delete/${obj.id}`);
}
