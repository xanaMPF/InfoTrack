<template>
  <nav-menu></nav-menu>
  <router-view />
</template>

<script>
    import NavMenu from './components/NavMenu.vue'

export default {
  name: 'App',
  components: {
      NavMenu
  }
}
</script>

<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        background: #EEEEEE;
        min-height: 100vh;
        padding-bottom: 30px;
    }

    table {
        margin: 20px;
        background: rgb(255, 255, 255);
        box-shadow: 0px 2px 4px rgba(169,169,169, 0.16), 0px 2px 4px rgba(169,169,169, 0.23);
        max-width: 80%;
        margin: 20px auto;
    }

    .label {
        width: 300px;
        text-align: left;
        vertical-align: top;
    }

    td {
        max-width: 250px;
    }

    .card {
        background: rgb(255, 255, 255);
        box-shadow: 0px 3px 6px rgba(0, 0, 0, 0.16), 0px 3px 6px rgba(0, 0, 0, 0.23);
    }

    @media only screen and (max-width: 600px) {
        .card {
            width: 100%;
            padding-top: 30px;
            padding-bottom: 30px;
        }
    }

    @media only screen and (min-width: 900px) {
        .card {
            width: 800px;
            padding: 15px;
            padding-top: 30px;
            padding-bottom: 30px;
        }

        .main {
            margin-left: auto;
            margin-right: auto;
        }
    }

    input[type='text'].field {
        box-sizing: border-box;
        border: 1px solid #C2C2C2;
        box-shadow: 1px 1px 4px #EBEBEB;
        padding: 7px;
        outline: none;
        margin: 10px;
        width: 600px;
    }

    input[type='checkbox'].field {
        box-sizing: border-box;
        border: 1px solid #C2C2C2;
        box-shadow: 1px 1px 4px #EBEBEB;
        outline: none;
    }

</style>
