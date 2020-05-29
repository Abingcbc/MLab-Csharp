<template>
    <iframe src='http://127.0.0.1:8888/?token=e0ea86604c88d5ded23cb973b33ffa1ecc5651bf5e680028'/>
</template>

<script>
    export default {
        name: "Lab",
        data() {
            return {
                modelName: 'Untitled',
                running: false,
                saving: false
            }
        },
        mounted() {

        }
    }
</script>

<style>
    iframe {
        width: 80%;
        height: 85%;
        border: 0;
        margin-top: 20px;
    }
</style>
