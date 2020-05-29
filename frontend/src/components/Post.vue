<template>
    <div style="margin-left: 200px;margin-right: 200px;">

        <el-card class="post" v-for="postData in postList" :key="postData.id">
            <el-row style="font-size: 30px">{{ postData.title }}</el-row>
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
                <el-aside style="width: 50px">
                    <el-button type="danger" icon="el-icon-delete" circle/>
                </el-aside>
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
                layout="total, prev, pager, next"
                style="margin-top: 20px;text-align: center;margin-bottom: 30px">
        </el-pagination>
    </div>
</template>

<script>
    export default {
        name: "Post",
        data() {
            return {
                postList: [],
                currentPage: 1,
                totalPost: 20
            }
        },
        mounted() {
            this.init()
        },
        methods: {
            init() {
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
            }
        }
    }
</script>

<style>
#post {
    width: 10%;
}
</style>
