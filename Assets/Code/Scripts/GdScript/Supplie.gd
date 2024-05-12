# @TOOL
# CLASS NAME
class_name Supplie

# EXTENDS
extends Node

# DOCS
# Classe feita para usar de base para recursos como Capacidade de Água, Energia, e Temperatura
# SIGNALS
# ENUMS
# CONSTANTS

# EXPORT VARIABLES
@export var MAX_CAPACITY: float
@export var INITIAL_CAPACITY: float
# PUBLIC VARIABLES

# PRIVATE VARIABLES
var current_capacity: float

# ONREADY VARIABLES

# BUILT-IN METHODS
func _ready():
	current_capacity = INITIAL_CAPACITY
	
# PUBLIC METHODS
func increase(value: float) -> void:
	if current_capacity + value > MAX_CAPACITY:
		current_capacity = MAX_CAPACITY
	else:
		current_capacity += value

func  decrease(value: float) -> void:
	if current_capacity - value < 0.0:
		current_capacity = 0.0
	else: 
		current_capacity -= value
		
# PRIVATE METHODS
# SUBCLASSES
