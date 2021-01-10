<template>
    <h1 id="tableLabel">Historical Results</h1>

    <table class="card main">
        <tr>
            <td class="label"><label>Keywords<span class="required">*</span></label></td>
            <td><input v-model="searchRequest.keywords" type="text" name="keywords" /></td>
        </tr>
        <tr>
            <td class="label">
                <label>Url<span class="required">*</span></label>
            </td>
            <td>
                <input v-model="searchRequest.url" type="text" name="url" />
            </td>
        </tr>
        <tr>
            <td class="label">
            </td>
            <td>
                <button class="btn" :disabled="disabledSearch" @click="loadHistoricalData">Search</button>
            </td>
        </tr>
    </table>

    <p v-if="pendingRequest && (!dataResults || !searchEngines)"><em>Loading...</em></p>
    <table v-else-if="dataResults && searchEngines" class='table table-striped' aria-labelledby="tableLabel">
        <thead>
            <tr>
                <th>Date</th>
                <template v-for="engine in searchEngines" :key="engine.id">
                    <th>{{engine.name}}</th>
                    <th>{{engine.name}} Best Rank</th>
                </template>
            </tr>
        </thead>
        <tbody>
            <tr v-for="result of dataResults" v-bind:key="result">
                <td>{{ new Date(result.date).toLocaleDateString() }}</td>
                <template v-for="engine in searchEngines" :key="engine.id">
                    <template v-if="result.results == null || result.results[engine.name] == null">
                        <td>No Data</td>
                        <td>No Data</td>
                    </template>
                    <template v-else>
                        <td>{{result.results[engine.name].ranks ? result.results[engine.name].ranks : 'Not in top 100'}}</td>
                        <td>{{result.results[engine.name].bestRank ? result.results[engine.name].bestRank : 'Not in top 100'}}</td>
                    </template>
                </template>
            </tr>
        </tbody>
    </table>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "HistoricalRankings",
        data() {
            return {
                searchEnginesAppendUrl: "/searchengines",
                historicalRankingsAppendUrl: "/ranks/daily",
                searchEngines: [],
                searchRequest: {
                    keywords: "",
                    url: "",
                },
                dataResults: null,
                pendingRequest: false,
            }
        },
        computed: {
            disabledSearch: function () {
                return this.searchRequest.keywords.length < 1 || this.searchRequest.url.length < 1;
            }
        },
        methods: {
            loadHistoricalData: function () {
                this.dataResults = null;
                this.pendingRequest = true;
                axios.post(this.historicalRankingsAppendUrl, this.searchRequest)
                    .then((response) => {
                        this.dataResults = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    })
                    .finally(() => {
                        this.pendingRequest = false;
                    });
                   },
                        getSearchEngines: function () {
                            axios.get(this.searchEnginesAppendUrl)
                                .then((response) => {
                                    this.searchEngines = response.data;
                                })
                                .catch(function (error) {
                                    alert(error);
                                });
                        },
        },
            mounted: function () {
                this.getSearchEngines();
            }
        }
</script>

<style scoped>
    .btn {
        display: inline-block;
        text-decoration: none;
        border: none;
        padding: 1em 2em;
        color: white;
        cursor: pointer;
        margin-top: 10px;
        background-color: #0dbb1b;
        background-repeat: no-repeat;
    }

    .required {
        color: red;
        font-weight: normal;
    }
</style>
