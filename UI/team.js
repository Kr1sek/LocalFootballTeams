const Teams={template:`
<div>

<button type="button"
class="btn btn-primary m-2 fload-end"
data-bs-toggle="modal"
data-bs-target="#modal"
@click="addClick()">
    Dodaj Drużunę
</button>

<table class="table">
    <thead>
        <tr>
            <th>
                Id
            </th>
            <th>
                Nazwa
            </th>
            <th> 
                Opcje
            </th>
        </tr>
    </thead>
    <tbody>
        <tr v-for="team in teams" :key="team.id">
            <td>{{team.id}}</td>
            <td>
                <img style='height: 30px; width: 30px;'
                :src="LogoPath+team.logo"/>
                {{team.name}}
            </td>
            <td>
                <button type="button"
                class="btn btn-light mr-1"
                data-bs-toggle="modal"
                data-bs-target="#modal"
                @click="editClick(team)">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                    <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                    <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                    </svg>
                </button>
                <button type="button"
                class="btn btn-light mr-1" @click="deleteClick(team.id)">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                    <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5Zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5Zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6Z"/>
                    <path d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1ZM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118ZM2.5 3h11V2h-11v1Z"/>
                    </svg>
                </button>
            </td>

        </tr>
    </tbody>
</table>

<div class="modal fade" id="modal" tabindex="-1"
    aria-labelledby="modalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">  
                <h5 class="modal-title" id="modalLabel">{{modalTitle}}</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal"
                aria-label="Close"></button>
            </div>

            <div class="modal-body">
                <div class="input-group mb-3">
                    <span class="input-group-text">Nazwa drużyny</span>
                    <input type="text" class="form-control" v-model="TeamName">
                </div>
                <div class="input-group mb-3">
                    <span class="input-group-text">Adres drużyny</span>
                    <input type="text" class="form-control" v-model="TeamAddress">
                </div>
                <div class="input-group mb-3">  
                    <span class="input-group-text">Rok założenia drużyny</span>
                    <input type="text" class="form-control" v-model="TeamStartYear">
                </div>
                <div class="p-2 w-50 bd-highlight">
                    <img style='height: 100px; width: 100px;' 
                        :src="LogoPath+LogoFileName" />
                    <input class="m-2" type="file" @change="imageUpload">
                </div>

                <button type="button" @click="createClick()"
                    v-if="TeamId==0" class="btn btn-primary">
                    Utwórz
                </button>
                <button type="button" @click="updateClick()"
                    v-if="TeamId!=0" class="btn btn-primary">
                    Zaktualizuj 
                </button>
            </div>
        </div>
    </div>
</div>


</div>
`,

data(){
    return{
        teams:[],
        modalTitle:"",
        TeamName:"",
        TeamId:0,
        TeamAddress:"",
        TeamStartYear:"",
        LogoFileName:"undefined.png",
        LogoPath:variables.PHOTO_URL
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
                this.LogoFileName=response.data;
            });
    },

    addClick(){
        this.modalTitle="Dodaj Drużynę";
        this.TeamId=0;
        this.TeamName="";
        this.TeamAddress="";
        this.TeamStartYear="";
        this.LogoFileName="undefined.png";
    },

    editClick(team){
        this.modalTitle="Edytuj Drużynę";
        this.TeamId=team.id;
        this.TeamName=team.name;
        this.TeamAddress=team.addres;
        this.TeamStartYear=team.startYear;
        this.LogoFileName=team.logo;
    },
    
    createClick(){
        axios.post(variables.API_URL+"teams",
        {
            Name:this.TeamName,
            Addres:this.TeamAddress,
            StartYear:this.TeamStartYear,
            Logo:this.LogoFileName
        })
        .then((response)=>{
            this.refreshData();
        });
    },

    updateClick(){
        axios.put(variables.API_URL+"teams/"+ this.TeamId,
        {
            Id:this.TeamId,
            Name:this.TeamName,
            Addres:this.TeamAddress,
            StartYear:this.TeamStartYear,
            Logo:this.LogoFileName
        })
        .then((response)=>{
            this.refreshData();
            alert("Zaktualizowano");
        });
    },
    deleteClick(id){
        if(!confirm("Czy jesteś pewny usunięcia?")){
            return;
        }
        axios.delete(variables.API_URL+"teams/"+id)
        .then((response)=>{
            this.refreshData();
            alert("Drużyna została usunięta.");
        })
    },
    imageUpload(event){
        let formData = new FormData();
        formData.append('file', event.target.files[0]);
        axios.post(variables.API_URL+"teams/savefile",
        formData)
        .then((response)=>{
            this.LogoFileName=response.data;
            this.refreshData();
        });
    }
},
mounted:function(){
    this.refreshData();
}

}