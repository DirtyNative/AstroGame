import 'package:astrogame_app/converters/guid_converter.dart';
import 'package:astrogame_app/converters/stellar_object_converter.dart';
import 'package:astrogame_app/converters/stellar_system_converter.dart';
import 'package:astrogame_app/models/stellar/systems/multi_object_system.dart';
import 'package:json_annotation/json_annotation.dart';

part 'solar_system.g.dart';

@GuidConverter()
@StellarObjectConverter()
@StellarSystemConverter()
@JsonSerializable()
class SolarSystem extends MultiObjectSystem {
  @JsonKey()
  bool isGenerated;

  SolarSystem();

  factory SolarSystem.fromJson(Map<String, dynamic> json) =>
      _$SolarSystemFromJson(json);
  Map<String, dynamic> toJson() => _$SolarSystemToJson(this);
}
