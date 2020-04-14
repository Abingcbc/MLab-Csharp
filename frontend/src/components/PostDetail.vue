<template>
    <div style="margin-right: 100px;margin-left: 100px;">
        <el-card id="article">
            <el-row style="font-size: 50px">{{ article.title }}</el-row>
            <el-row>
                <el-avatar :src="article.avatarUrl" :size="30"/>
                {{ article.author}}
            </el-row>
            <el-row>
                {{ article.content }}
            </el-row>
            <el-row>
                <el-button icon="el-icon-thumb">
                    {{ article.like }}
                </el-button>
                <el-icon class="el-icon-chat-dot-square"
                         style="margin-left: 10px"
                />
                {{ article.comment }}
            </el-row>
        </el-card>
        <div style="margin-top: 15px;">
            <el-input placeholder="评论一下" v-model="input3" class="input-with-select">
                <el-button slot="append" icon="el-icon-chat-dot-square"></el-button>
            </el-input>
        </div>
        <el-card v-for="comment in comments" :key="comment.id">
            <el-row>
                <el-avatar :src="comment.avatarUrl" :size="20"/>
                {{ comment.author}}
            </el-row>
            <el-row>
                {{ comment.content }}
            </el-row>
            <el-row>
                <el-button icon="el-icon-thumb">
                    {{ comment.like }}
                </el-button>
            </el-row>
        </el-card>
        <el-pagination
                background
                :current-page.sync="currentPage"
                @current-change="loadCommentList"
                :total="article.comment"
                layout="total, prev, pager, next"
                style="margin-top: 20px;text-align: center;margin-bottom: 30px"
        >
        </el-pagination>
    </div>
</template>

<script>
    export default {
        name: "PostDetail",
        data() {
            return {
                article: {},
                comments: [],
                currentPage: 0,
            }
        },
        mounted() {
            this.init();
        },
        methods: {
            init() {
                this.article = {
                    id: 0,
                    title: "adfasdfas",
                    image: "https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png",
                    avatarUrl: "https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png",
                    author: "adsfasdf",
                    content: "asdfasdaskdgh;aksdhgjasjdfhakshdgkashdglasdgasdbgaghiweuhgiawhegiwuhegiawehi",
                    like: 1,
                    comment: 1
                };
                for (let i = 0; i < 10; i++) {
                    this.comments.push({
                        id: i,
                        avatarUrl: "https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png",
                        author: "adsfasdf",
                        content: "asdfasdaskdgh;aksdhgj",
                        like: 1,
                    })
                }
            },
            loadCommentList(value) {
                const path = this.$router.app.$route.query;
                this.currentPage = value;
                if (path.search) {
                    this.init();
                } else {
                    this.init();
                }
                document.body.scrollTop = 0;
                document.documentElement.scrollTop = 0;
            },
        }
    }
</script>

<style>
    .el-row {
        margin-top: 20px;
    }

    .el-card {
        margin-top: 20px;
    }
</style>
