class CourseScheduler {
    constructor(numCourses, prerequisites) {
        this.adjList = new Map();
        this.visited = new Array(numCourses).fill(false);
        this.recStack = new Array(numCourses).fill(false);

        for(let i = 0; i < numCourses; i++) {
            this.adjList.set(i, []);
        }

        for(let [course, pre] of prerequisites) {
            this.adjList.get(pre).push(course);
        }
    }
}