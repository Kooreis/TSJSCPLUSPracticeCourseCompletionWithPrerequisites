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