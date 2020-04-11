import Vue from 'vue';
import Router from 'vue-router';

// import Content from '@/components/Content/Content.vue';
import Login from '@/components/Login'
import Register from "@/components/Register";
import Lab from '@/components/Lab'
// import Community from "@/components/Community";

Vue.use(Router);

export default new Router({
    mode: 'history',
    base: '',
    routes: [
        // {path: '/', component: Content, name: 'home'},
        {path: '/login', component: Login, name: 'login'},
        {path: '/register', component: Register, name: 'register'},
        {path: '/lab', component: Lab, name: 'lab'},
        // {path: '/community', component: Community, name: 'community'}
    ]
});
