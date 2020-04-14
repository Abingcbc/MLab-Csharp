<template>
    <el-container style="margin-right: 100px; margin-left: 100px">
        <el-main>
            <el-card id="post" v-for="postData in postList" :key="postData.id">
                <el-row style="font-size: 30px">{{ postData.title }}</el-row>
                <el-row>
                    <el-avatar :src="postData.avatarUrl" :size="20"/>
                    {{ postData.author}}
                </el-row>
                <el-container>
                    <el-aside style="width: 150px">
                        <img :src="postData.image" alt=""/>
                    </el-aside>
                    <el-main>
                        {{ postData.content }}...
                        <el-button type="text" @click.native="detail(postData.id)">
                            查看详情
                        </el-button>
                    </el-main>
                </el-container>
                <el-row>
                    <el-col :span="1">
                        <el-icon class="el-icon-thumb"/>
                        {{ postData.like }}
                    </el-col>
                    <el-col :span="1">
                        <el-icon class="el-icon-chat-dot-square"/>
                        {{ postData.comment }}
                    </el-col>
                </el-row>
            </el-card>
            <el-pagination
                    background
                    :current-page.sync="currentPage"
                    @current-change="loadPostList"
                    :total="totalPost"
                    layout="total, prev, pager, next">
            </el-pagination>
        </el-main>
        <el-aside width="300px" style="margin-top: 20px;">
            <el-card>
                hot
            </el-card>
        </el-aside>
    </el-container>
</template>

<script>
    export default {
        name: "Community",
        data() {
            return {
                postList: [],
                currentPage: 1,
                totalPost: 100
            }
        },
        mounted() {
            // must have the page
            if (!this.$router.app.$route.query.page) {
                this.$router.push('/community?page=1')
            }
            this.init()
        },
        methods: {
            init() {
                this.currentPage = parseInt(this.$router.app.$route.query.page);
                this.postList = [];
                for (let i = 0; i < 10; i++) {
                    this.postList.push({
                        id: i,
                        title: this.currentPage.toString(),
                        image: "https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png",
                        avatarUrl: "https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png",
                        author: "adsfasdf",
                        content: "asdfasdaskdgh;aksdhgj",
                        like: 1,
                        comment: 1
                    })
                }
            },
            loadPostList(value) {
                const path = this.$router.app.$route.query;
                this.currentPage = value;
                if (path.search) {
                    this.$router.push("/community?search="+path.search+"&page="+value.toString());
                    this.init();
                } else {
                    this.$router.push("/community?page="+value.toString());
                    this.init();
                }
                document.body.scrollTop = 0;
                document.documentElement.scrollTop = 0;
            },
            detail(id) {
                this.$router.push('/postDetail?id='+id.toString());
            }
        }
    }
</script>

<style>
#post {
    margin-bottom: 10px;
}
</style>
