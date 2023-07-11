Here is a TypeScript solution for the problem:

```typescript
class Course {
    isVisited = false;
    isStack = false;
    children: Course[] = [];
}

function canFinish(numCourses: number, prerequisites: number[][]): boolean {
    const courses: Course[] = Array(numCourses).fill(null).map(() => new Course());

    for (let i = 0; i < prerequisites.length; i++) {
        courses[prerequisites[i][0]].children.push(courses[prerequisites[i][1]]);
    }

    for (let i = 0; i < numCourses; i++) {
        if (isCyclic(courses[i])) {
            return false;
        }
    }

    return true;
}

function isCyclic(course: Course): boolean {
    if (course.isStack) {
        return true;
    }

    if (course.isVisited) {
        return false;
    }

    course.isVisited = true;
    course.isStack = true;

    for (let i = 0; i < course.children.length; i++) {
        if (isCyclic(course.children[i])) {
            return true;
        }
    }

    course.isStack = false;

    return false;
}

console.log(canFinish(2, [[1,0]])); // true
console.log(canFinish(2, [[1,0],[0,1]])); // false
```

This solution uses a depth-first search (DFS) to detect cycles in the graph. It uses two flags: `isVisited` and `isStack`. `isVisited` is true if the node has been visited at least once, and `isStack` is true if the node is part of the current DFS stack. If a node is part of the current DFS stack and is visited again, it means there is a cycle.