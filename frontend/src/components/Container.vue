<template>
    <el-container>
        <el-aside style="text-align: center">
            <el-button type="primary" icon="el-icon-plus" style="margin-top: 40px">
                创建新容器
            </el-button>
        </el-aside>
        <el-main>
            <el-card class="model" v-for="modelData in modelList" :key="modelData.id">
                <el-container>
                    <el-main>
                        <el-row style="font-size: 30px">{{ modelData.title }}</el-row>
                        <el-row>
                            最近修改时间：{{modelData.updateTime}}
                        </el-row>
                    </el-main>
                    <el-aside style="width: 50px">
                        <el-button type="danger" icon="el-icon-delete" circle/>
                    </el-aside>
                </el-container>
            </el-card>
            <el-pagination
                    background
                    :current-page.sync="currentPage"
                    @current-change="loadmodelList"
                    :total="totalModel"
                    layout="total, prev, pager, next"
                    style="margin-top: 20px;text-align: center;margin-bottom: 30px">
            </el-pagination>
        </el-main>
    </el-container>
</template>

<script>
    export default {
        name: "Container",
        data() {
            return {
                modelList: [],
                currentPage: 1,
                totalModel: 20
            }
        },
        mounted() {
            this.init()
        },
        methods: {
            init() {
                this.modelList = [];
                for (let i = 0; i < 10; i++) {
                    this.modelList.push({
                        id: i,
                        title: 'adfsdfasdf',
                        image: "https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png",
                        updateTime: 'asdfasdf'
                    })
                }
            }
        }
    }
</script>

<style>
.model {
    width: 300px;
    display: inline-block;
    margin-right: 20px;
    margin-top: 20px;
}
</style>
