package io.workoutapi.exercise;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ExerciseController {

	@Autowired
	private ExerciseService exerciseService;
	
	@RequestMapping("/exercises")
	public List<Exercise> getAllExercises() {
		return exerciseService.getAllExercises();
	}
	
	@RequestMapping("/exercises/{id}")
	public Exercise getExercise(@PathVariable String id) {
		return exerciseService.getExercise(id);
	}
	
	@PostMapping(value = "/exercises")
	public void addExercise(@RequestBody Exercise exercise) {
		exerciseService.addExercise(exercise);
	}
	
	@PutMapping(value = "/exercises/{id}")
	public void updateExercise(@RequestBody Exercise exercise, @PathVariable String id) {
		exerciseService.updateExercise(exercise, id);
	}
	
	@DeleteMapping(value = "/exercises/{id}")
	public void deleteExercise(@PathVariable String id) {
		exerciseService.deleteExercise(id);
	}
}
