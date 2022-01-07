import axios from 'axios';

class movieService {
    getAll = async() => {
        return await axios.get("https://localhost:44303/api/movies")
            .catch(e => {
                console.log(e);
            });
    }
    getById = async(id) => {
        return await axios.get(`https://localhost:44303/api/movies/${id}`)
            .catch(e => {
                console.log(e);
            });
    }
    add = async(movie) => {
        return await axios.post("https://localhost:44303/api/movies/", movie)
            .catch(e => {
                console.log(e);
            });
    }
    update = async(movie, id) => {
        return await axios.put(`https://localhost:44303/api/movies/${id}`, movie)
            .catch(e => {
                console.log(e);
            });
    }
    delete = async(id) => {
        return await axios.delete(`https://localhost:44303/api/movies/${id}`)
            .catch(e => {
                console.log(e);
            });
    }
}

export default new movieService();