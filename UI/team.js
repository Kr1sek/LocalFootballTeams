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
            <td>
            <img 
                :src="PhotoPath+team.logo"/></div>
            {{team.name}}</td>
            
        </tr>
    </tbody>
</table>

`,

data(){
    return{
        teams:[],
        PhotoFileName:"undefined.png",
        PhotoPath:variables.PHOTO_URL
    };
},
methods:{
    refreshData(){
        axios.get(variables.API_URL+"teams")
        .then((response)=>{
            this.teams=response.data;
        });
    },

    iamgeUpload(event){
        let formData = new FormData();
        formData.append('file',event.target.files[0]);
        axios.post(
            variables.API_URL+"employee/savefile",
            formData)
            .then((response)=>{
                this.PhotoFileName=response.data;
            });
    }
},
mounted:function(){
    this.refreshData();
}

}