import "./App.css";
import axios from "axios";

function App() {
  return (
    <div className="App">
      <img 
      src="https://cdn.tgdd.vn/Files/2020/06/08/1261696/moi-tai-bo-hinh-nen-asus-rog-2020-moi-nhat_800x450.jpg"
      alt="new"
      />
     <div className="container">
        <form onSubmit={(e) => login(e)}>
          <div className="mb-3">
            <label for="exampleInputAcc" className="form-label">
              Tên tài khoản
            </label>
            <input
              type="text"
              className="form-control"
              id="exampleInputAcc"
            />
            <div id="emailHelp" className="form-text">              
            </div>
          </div>
          <div className="mb-3">
            <label for="exampleInputPassword1" className="form-label">
              Mật khẩu
            </label>
            <input
              type="password"
              className="form-control"
              id="exampleInputPassword1"
            />
          </div>
          <button type="submit" className="btn btn-primary">
            Đăng nhập
          </button>
        </form>
      </div>
    </div>
  );
}

function login(e) {
  e.preventDefault();
  let request = {
    TenUser: document.getElementById("exampleInputAcc").value,
    MatKhau: document.getElementById("exampleInputPassword1").value,
  };
  axios
    .post("http://localhost:8080/api/login", request)
    .then((resp) => {
      alert(resp.data.message);
    })
    .catch((err) => {
      console.log(err);
    });
}

export default App;
