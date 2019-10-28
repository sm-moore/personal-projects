#[macro_use]
extern crate actix_web;

use actix_web::http::{header, Method, StatusCode};
use actix_web::{
    error, guard, middleware, web, App, Error, HttpRequest, HttpResponse, HttpServer,
    Result,
};

impl Error for ApplicationError {
    fn description(&self) -> &str {
        "I'm the superhero of errors"
    }

    fn cause(&self) -> Option<&dyn Error> {
        Some(&self.side)
    }
}

struct TaskManager;

impl TaskManagerAPI for TaskManager {
     fn get_task(
        &self,
        request: &TaskManagerRequest,
        task_id: &str,
    ) -> Box<Future<Item = responses::TaskResponse, Error = ApplicationError>> {
        handlers::getTask(request, task_id)
    }
}

fn main() {
    actix_web::server::HttpServer::new(|| {
        let api = TaskManager;
        App::with_state(Arc::new(api))
        .resource("/task/{id}", |r| { // Here r is a ResourceHandler https://docs.rs/actix-web/0.6.3/actix_web/dev/struct.ResourceHandler.html
           r.method(actix_web::http::Method::GET)
           .with_async(get_task)
        })
    })
    .bind("127.0.0.1:8080")
    .expect("Could not build server")
    .run();
}

pub fn get_task(
    extractors: (TaskManagerRequest, Path<String>)
) -> Box<Future<Item = HttpResponse, Error = ApplicationError>> {
    let (request, id) = extractors;
    Box::new(
        request
            .api
            .get_task(&request, id)
            .map(|res| {
                HttpResponse::Ok()
                .header("Content-Type", "application/json")
                .json(res);
            })
    )
}