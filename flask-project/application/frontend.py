from flask import Blueprint, render_template, flash, redirect, url_for
from flask_bootstrap import __version__ as FLASK_BOOTSTRAP_VERSION
from markupsafe import escape

frontend = Blueprint('frontend', __name__)


# Our index-page just shows a quick explanation. Check out the template
# "templates/index.html" documentation for more details.
@frontend.route('/')
def index():
    return render_template('index.html')
