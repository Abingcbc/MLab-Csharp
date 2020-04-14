<template>
    <div>
        <el-menu
                class="el-menu-demo"
                mode="horizontal"
                active-text-color="#ffd04b">
            <el-menu-item @click.native="home">
                <img src="../../public/logo_word.png" alt="" width="80" height="60"/>
            </el-menu-item>
            <el-menu-item @click.native="lab">
                画板
            </el-menu-item>
            <el-menu-item @click.native="community">
                社区
            </el-menu-item>
            <el-menu-item>
                <el-input placeholder="搜索文章"
                          v-model="input">
                    <el-button slot="append" icon="el-icon-search"/>
                </el-input>
            </el-menu-item>
            <el-menu-item v-if="isCommunity">
                <el-button round type="primary" @click.native="createPost">
                    写文章
                </el-button>
            </el-menu-item>
            <el-submenu style="float: right" index="4">
                <template slot="title">
                    <el-avatar :size="30"
                               :src="avatarUrl"/>
                </template>
                <el-menu-item v-if="!isLogin" @click.native="login">登录</el-menu-item>
                <el-menu-item v-if="isLogin">个人中心</el-menu-item>
                <el-menu-item v-if="isLogin">我的模型</el-menu-item>
                <el-menu-item v-if="isLogin">我的文章</el-menu-item>
                <el-menu-item v-if="isLogin">退出</el-menu-item>
            </el-submenu>
        </el-menu>
    </div>
</template>

<script>
    export default {
        name: "Header",
        data() {
            return {
                input: '',
                isLogin: false,
                isCommunity: true,
                avatarUrl: 'https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png'
            };
        },
        methods: {
            handleSelect: () => {

            },
            home() {
                this.$router.push('/')
            },
            login() {
                if (this.$router.path !== '/login') {
                    this.$router.push('/login')
                }
            },
            lab() {
                if (this.$router.path !== '/lab') {
                    this.$router.push('/lab')
                }
            },
            community() {
                this.$router.push('/community?page=1');
                this.isCommunity = true;
            },
            createPost() {
                this.$router.push('/createPost')
            }
        }
    }
</script>

<style>

</style>
