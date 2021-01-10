import { createWebHistory, createRouter } from "vue-router";
import Ranking from "@/components/Ranking.vue";
import HistoricalRankings from "@/components/HistoricalRankings.vue";

const routes = [
    {
        path: "/",
        name: "Ranking",
        component: Ranking,
    },
    {
        path: "/HistoricalRankings",
        name: "HistoricalRankings",
        component: HistoricalRankings,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;