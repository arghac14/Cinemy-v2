// import axiosInstance from './index.js';
import axios from 'axios';

class userAPIService {
    getUser = async(data) => {
        return await axios.post(`https://localhost:44303/api/users/login`, data)
            .catch(e => {
                console.log(e);
            });
    }
    add = async(data) => {
        console.log(data)
        return await axios.post("https://localhost:44303/api/users/signup", data)
            .catch(e => {
                console.log(e);
            });
    }
}

export default new userAPIService();