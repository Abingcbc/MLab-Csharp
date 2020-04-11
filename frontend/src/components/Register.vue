<template>
    <div>
        <div class="register-wrap">
            <img src="../../public/logo_figure.png" class="logo-register" width="100" height="100" alt="">
            <el-form @submit.native.prevent>
                <el-form-item>
                    <el-input type="text" :placeholder="'用户名'" v-model="username" autofocus clearable/>
                </el-form-item>
                <el-form-item>
                    <el-input type="password" :placeholder="'密码'" v-model="password" clearable/>
                </el-form-item>
                <el-form-item>
                    <el-input type="password" :placeholder="'重复密码'" v-model="rPassword" clearable/>
                </el-form-item>
                <el-form-item style="text-align: center">
                    <el-button type="primary" @click="register" round>
                        登录
                    </el-button>
                    <el-button type="text">注册</el-button>
                </el-form-item>
            </el-form>

        </div>
    </div>
</template>

<script>
    // import http from 'axios';

    export default {
        name: "Register",
        data() {
            return {
                username: '',
                password: '',
                rPassword: '',
                error: false,
                errorShake: false
            }
        },
        methods: {
            register() {
                this.error = false;
                console.log("register")
            }
        }
    }
</script>

<style>
    .register-wrap {
        max-width: 320px;
        margin-left: auto;
        margin-right: auto;
        padding-left: 20px;
        padding-right: 20px;
    }

    .register-wrap:before {
        content: '';
        display: table;
    }

    .register-wrap:after {
        content: '';
        display: table;
        clear: both;
    }

    .logo-register {
        display: block;
        margin: 100px auto 50px auto;
    }
</style>
