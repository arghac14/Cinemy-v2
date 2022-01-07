import axios from 'axios';
import axiosInstance from './index.js';

class movieAPIService {
    getAll = async() => {
        return await axios.get("https://localhost:44303/api/movies")
            .catch(e => {
                console.log(e);
            });
    }
    getById = async(id) => {
        return await axiosInstance.get(`movies/${id}`)
            .catch(e => {
                console.log(e);
            });
    }
    add = async(movie) => {
        return await axiosInstance.post("movies/", movie)
            .catch(e => {
                console.log(e);
            });
    }
    update = async(movie, id) => {
        return await axiosInstance.put(`movies/${id}`, movie)
            .catch(e => {
                console.log(e);
            });
    }
    delete = async(id) => {
        return await axiosInstance.delete(`movies/${id}`)
            .catch(e => {
                console.log(e);
            });
    }
}

export default new movieAPIService();