import axios from 'axios';
import { stringify } from 'qs';

const axiosInstance = axios.create({
  baseURL: "https://localhost:44303/api/",
  paramsSerializer: function (params) {
    return stringify(params, { arrayFormat: 'indices', allowDots: true })
  }
});

axiosInstance.interceptors.request.use(function (config) {
var token = localStorage.getItem('accessToken');
// var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJzdXBlcmFkbWlvbiIsImp0aSI6ImRmMDEzNmI5LWFlOGUtNDYyMi05Y2Q4LTQ1N2Q1M2YyNjc0ZCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoic3VwZXJhZG1pb24iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNjQwMTg5NTQzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo0NDMwMyJ9.osaecO3a8wy4JFP-3dC_JbU6GGpi422v_YcyW3vWFhg";
  if (token)
    config.headers.Authorization = `Bearer ${token}`;
  return config;
});
axiosInstance.interceptors.response.use(function (response) {
  return response;
});

export default axiosInstance;