const teams={template:`
<table class="table">
    <thead>
        <tr>
            <th>
                Id
            </th>
            <th>
                Nazwa
            </th>
        </tr>
    </thead>
    <tbody>
        <tr v-for="team in teams" :key="team.id">
            <td>{{team.id}}</td>
            <td>{{team.name}}</td>
        </tr>
    </tbody>
</table>
`,

data(){
    return{
        teams:[]
    };
},
methods:{
    refreshData(){
        axios.get(variables.API_URL+"teams")
        .then((response)=>{
            this.teams=response.data;
        });
    }
},
mounted:function(){
    this.refreshData();
}

}