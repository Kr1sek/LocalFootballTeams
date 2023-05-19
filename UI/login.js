const Login = {template:`
<form @submit.prevent="handleSubmit()">
  <section class="vh-100">
    <div class="container row d-flex justify-content-center py-5 h-100">
        <div class="col-12 col-md-8 col-lg-6 col-xl-5">
          <div class="card shadow-2-strong" style="border-radius: 1rem;">
            <div class="card-body p-5 text-center">

              <h3 class="mb-5">Sign in</h3>

              <div class="form-outline mb-4">
                <input type="email" id="email" class="form-control" v-model="UserEmail" />
                <label class="form-label" for="userEmail">Email</label>
              </div>

              <div class="form-outline mb-4">
                <input type="password" id="password" class="form-control" v-model="UserPassword"/>
                <label class="form-label" for="userPassword">Password</label>
              </div>
              <button class="btn btn-primary btn-lg btn-block">Login</button>
            </div>
          </div>
        </div>
    </div>
  </section>
</form>
` ,

data(){
  return{
    UserEmail:"",
    UserPassword:""
  }
},
methods:{

    
  async handleSubmit(){
      const result = axios.post(variables.API_URL+'Account/login',{
        email:this.UserEmail,
        password:this.UserPassword
      })
      .then((response)=>{
        console.log(this.UserEmail, this.UserPassword);
        console.log(response.data);
      });
      
      
    }
}


}

