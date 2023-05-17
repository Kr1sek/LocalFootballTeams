const Login = {template:`
<section class="vh-100">
  <div class="container row d-flex justify-content-center py-5 h-100">
      <div class="col-12 col-md-8 col-lg-6 col-xl-5">
        <div class="card shadow-2-strong" style="border-radius: 1rem;">
          <div class="card-body p-5 text-center">

            <h3 class="mb-5">Sign in</h3>

            <div class="form-outline mb-4">
              <input type="email" id="email" class="form-control form-control-lg" />
              <label class="form-label" for="email">Email</label>
            </div>

            <div class="form-outline mb-4">
              <input type="password" id="password" class="form-control form-control-lg" />
              <label class="form-label" for="password">Password</label>
            </div>
            <button class="btn btn-primary btn-lg btn-block" type="submit">Login</button>
          </div>
        </div>
      </div>
  </div>
</section>
`,}