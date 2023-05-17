const routes=[
    {path: '/teams', component: Teams},
    {path: '/login', component: Login},
    {path: '/register', component: Register}
]


const router = VueRouter.createRouter({
    history: VueRouter.createWebHashHistory(),
    routes,
})

const app = Vue.createApp({})
    
app.use(router)

app.mount('#app')