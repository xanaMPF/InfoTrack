<template>
    <div id="ranking">
        <h1 id="tableLabel">Search Ranking</h1>

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
                    <label>Search Engines<span class="required">*</span></label>
                </td>
                <td>
                    <template v-if="searchEngines != null">
                        <div class="searchEngineEntry" v-for="sh in searchEngines" :key="sh.id">
                            <input v-model="searchRequest.searchEngines" type="checkbox" :value="sh" checked />
                            <label>{{sh.name}}</label>
                        </div>
                    </template>
                    <div v-else>
                        Loading search engines...
                    </div>
                </td>
            </tr>
            <tr>
                <td class="label">
                </td>
                <td>
                    <button class="btn" :disabled="disabledSearch" @click="getRankings">Search</button>
                </td>
            </tr>
        </table>

        <table v-if="searchResults" class='table table-striped' aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Search Engine</th>
                    <th>Ranks</th>
                    <th>Best Rank</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="result in searchResults" v-bind:key="result">
                    <td>{{result.searchEngineName}}</td>
                    <td>{{result.ranks ? result.ranks : 'Not in top 100'}}</td>
                    <td>{{result.bestRank ? result.bestRank : 'Not in top 100'}}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import axios from 'axios';
    export default {
        name: 'ranking',
        data() {
            return {
                searchEnginesAppendUrl: "/searchengines",
                ranksAppendUrl: "/ranks",
                searchEngines: null,
                searchRequest: {
                    keywords: "",
                    url: "",
                    searchEngines: []
                },
                searchResults: null,
            }
        },
        computed: {
            disabledSearch: function() {
                return this.searchRequest.keywords.length < 1 ||
                    this.searchRequest.url.length < 1 ||
                    this.searchRequest.searchEngines.length < 1;
            },
        },
        methods: {
            getRankings: function() {
                axios.post(this.ranksAppendUrl, this.searchRequest)
                    .then((response) => {
                        this.searchResults = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            getSearchEngines: function() {
                axios.get(this.searchEnginesAppendUrl)
                    .then((response) => {
                        this.searchEngines = response.data;
                        this.searchRequest.searchEngines = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            }
        },
        created: function () {
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

    .searchEngineEntry {
        display: flex;
        flex-direction: row;
        height: 35px;
        width: 200px;
    }

        .searchEngineEntry > input {
            margin: auto 8px auto 0px;
        }
        
        .searchEngineEntry > label {
            margin: auto 0;
        }
</style>
