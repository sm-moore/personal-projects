use actix_web::dev::JsonConfig;
use std::sync::Arc;

pub struct TaskManagerRequest {
    pub api: Arc<TaskManagerAPI>
}

// Define a custom extractor for our request.
impl FromRequest<Arc<TaskManagerAPI>> for TaskManagerRequest {
    type Config = JsonConfig<Arc<TaskManagerAPI>>;
    type Result = Result<Self, ApplicationError>;
    fn from_request(req: &HttpRequest<Arc<TaskManagerAPI>>, _: &Self::Config) -> Self::Result {
        let state: State<Arc<TaskManagerAPI>> = State::from_request(req, &());
        Ok(AdaptorRequest{
            api: state.clone()
        })
    }
}

pub trait TaskManagerAPI {
    fn get_task(
        &self,
        _request: &TaskManagerRequest,
        _task_id: &str,
    ) -> Box<Future<Item = responses::TaskResponse, Error = ApplicationError>> {
        Box::new(futures::future::err(ApplicationError::Unimplemented))
    }
}