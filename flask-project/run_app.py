from application import create_app

if __name__ == '__main__':
    app = create_app()
    if app.debug:
        app.run(debug=True)
    else:
        app.run(host='0.0.0.0')
