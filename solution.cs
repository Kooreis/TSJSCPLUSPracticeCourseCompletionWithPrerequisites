Here is a JavaScript solution using Depth-First Search (DFS) to detect cycles in a directed graph:

```javascript
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

    isCyclicUtil(i) {
        if(this.recStack[i]) {
            return true;
        }

        if(this.visited[i]) {
            return false;
        }

        this.visited[i] = true;
        this.recStack[i] = true;

        let children = this.adjList.get(i);

        for(let c = 0; c < children.length; c++) {
            if(this.isCyclicUtil(children[c])) {
                return true;
            }
        }

        this.recStack[i] = false;
        return false;
    }

    isCyclic() {
        for(let node = 0; node < this.visited.length; node++) {
            if(this.isCyclicUtil(node)) {
                return true;
            }
        }
        return false;
    }
}

function canFinish(numCourses, prerequisites) {
    let courseScheduler = new CourseScheduler(numCourses, prerequisites);
    return !courseScheduler.isCyclic();
}

console.log(canFinish(2, [[1,0]])); // true
console.log(canFinish(2, [[1,0],[0,1]])); // false
```

This console application creates a CourseScheduler class that represents a directed graph of courses and their prerequisites. The `canFinish` function creates a new CourseScheduler and checks if there is a cycle in the graph. If there is a cycle, it means that there are circular dependencies between courses and not all courses can be finished, so it returns false. If there is no cycle, it means that all courses can be finished, so it returns true.