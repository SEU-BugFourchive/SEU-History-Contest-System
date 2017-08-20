import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
import 'chartist';

Vue.use(VueRouter);

const router = new VueRouter({
    mode: 'history',
    routes: [
        {
            path: '/login',
            component: require('./components/login/login.vue.html')
        },
        {
            path: '/ans',
            component: require('./components/ans/ans.vue.html'),
            children: [
                {
                    path: 'sheet',
                    component: require('./components/ans/sheet/ans_sheet.vue.html')
                },
                {
                    path: 'result',
                    component: require('./components/ans/result/ans_result.vue.html')
                }
            ]
        },
        {
            path: '/dashboard',
            component: require('./components/dashboard/dashboard.vue.html'),
            children: [
                {
                    path: 'statistics',
                    component: require('./components/dashboard/statistics/statistics.vue.html')
                },
                {
                    path: 'general',
                    component: require('./components/dashboard/general/general.vue.html')
                }
            ]
        }
    ]
})
router.push('/login');

new Vue({
    el: '#app-root',
    router,
    render: h => h(require('./components/app/app.vue.html'))
});
