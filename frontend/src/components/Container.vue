<template>
    <el-container>
        <el-aside style="text-align: center">
            <el-button type="primary" icon="el-icon-plus" style="margin-top: 40px"
                       @click="showCreate = true">
                创建新容器
            </el-button>
            <el-dialog title="创建新容器" :visible.sync="showCreate" style="text-align: center">
                <el-form :model="newContainer" style="width: 200px; display: inline-block">
                    <el-form-item label="容器名称">
                        <el-input v-model="newContainer.name" autocomplete="off"></el-input>
                    </el-form-item>
                    <el-form-item label="容器类型">
                        <el-select v-model="newContainer.type" placeholder="请选择容器类型">
                            <el-option label="基础包" value="0"></el-option>
                            <el-option label="TensorFlow包" value="1"></el-option>
                        </el-select>
                    </el-form-item>
                </el-form>
                <div slot="footer" class="dialog-footer">
                    <el-button @click="dialogFormVisible = false">取 消</el-button>
                    <el-button type="primary" @click="dialogFormVisible = false">确 定</el-button>
                </div>
            </el-dialog>
        </el-aside>
        <el-main>
            <el-card class="container" v-for="containerData in containerList" :key="containerData.id">
                <el-container>
                    <el-main>
                        <el-row style="font-size: 30px">{{ containerData.title }}</el-row>
                        <el-row>
                            最近修改时间：{{containerData.updateTime}}
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
                    @current-change="loadContainerList"
                    :total="totalContainer"
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
                containerList: [],
                currentPage: 1,
                totalContainer: 20,
                showCreate: false,
                newContainer: {
                    name: "",
                    type: 0
                }
            }
        },
        mounted() {
            this.init()
        },
        methods: {
            init() {
                this.containerList = [];
                for (let i = 0; i < 10; i++) {
                    this.containerList.push({
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
    .container {
        width: 300px;
        display: inline-block;
        margin-right: 20px;
        margin-top: 20px;
    }
</style>
