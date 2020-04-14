<template>
    <div>
        <h3 style="text-align: center">
            创建新的文章
        </h3>
        <mavon-editor ref=mde
                      v-model="value"
                      @imgAdd="$imgAdd"
        />
        <div style="text-align: center; margin-top: 30px">
            <el-form ref="form" :model="form" label-width="80px">
                <el-form-item>
                    <el-button type="primary"
                               @click.native="onSubmit">提交</el-button>
                    <el-button type="text">取消</el-button>
                </el-form-item>
            </el-form>
        </div>
    </div>
</template>

<script>
    export default {
        name: "CreatePost",
        data() {
            return {
                value: '',
                form: {}
            }
        },
        methods: {
            $imgAdd(pos, $file) {
                var formdata = new FormData();
                formdata.append('smfile', $file);
                this.$axios({
                    method: 'post',
                    url: '/image',
                    headers: {
                        'Content-Type': 'multipart/form-data',
                        'Authorization': 'ZNtF4YN9va6lBsSKpg31PKlkOCZIcEsC'
                    },
                    data: formdata
                }).then((response) => {
                    console.log(response);
                    if (response.data['success']) {
                        this.$refs.mde.$img2Url(pos, response.data['data']['url'])
                    } else {
                        // repeat upload
                        this.$refs.mde.$img2Url(pos, response.data['images'])
                    }
                })
            },
            onSubmit() {
                this.$router.push('/community')
                // this.$axios({
                //     method: 'post',
                //     url: '/server/community-service/post/publish',
                //     data: {
                //         username: localStorage.getItem('username'),
                //         title: this.value.split('\n')[0],
                //         content: this.value,
                //     }
                // }).then(() => {
                //     this.$router.push('/society')
                // })
            }
        }
    }
</script>

<style scoped>

</style>
