use serde_derive::{Deserialize, Serialize};

#[derive(Clone, Serialize, Deserialize, Debug)]
#[serde(rename_all = "PascalCase")]
pub struct TaskResponse {
    pub name: String,
    pub id: String,
    pub description: String,
}