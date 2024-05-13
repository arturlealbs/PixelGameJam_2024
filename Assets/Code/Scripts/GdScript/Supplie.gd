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
	current_capacity = clamp(current_capacity + value, 0, MAX_CAPACITY)

func  decrease(value: float) -> void:
	current_capacity = clamp(current_capacity - value, 0, MAX_CAPACITY)
		
# PRIVATE METHODS
# SUBCLASSES
