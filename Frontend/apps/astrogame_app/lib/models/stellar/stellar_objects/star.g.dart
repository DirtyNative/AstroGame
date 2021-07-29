// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'star.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Star _$StarFromJson(Map<String, dynamic> json) {
  return Star()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..name = json['name'] as String
    ..parentSystemId =
        const GuidConverter().fromJson(json['parentSystemId'] as String)
    ..averageDistanceToCenter =
        (json['averageDistanceToCenter'] as num?)?.toDouble()
    ..rotationSpeed = (json['rotationSpeed'] as num).toDouble()
    ..averageTemperature = json['averageTemperature'] as int
    ..assetName = json['assetName'] as String
    ..coordinates =
        Coordinates.fromJson(json['coordinates'] as Map<String, dynamic>)
    ..starType = _$enumDecode(_$StarTypeEnumMap, json['starType'])
    ..scale = (json['scale'] as num).toDouble()
    ..axialTilt = (json['axialTilt'] as num).toDouble()
    ..resources = (json['resources'] as List<dynamic>?)
        ?.map((e) => StellarObjectResource.fromJson(e as Map<String, dynamic>))
        .toList()
    ..order = json['order'] as int;
}

Map<String, dynamic> _$StarToJson(Star instance) => <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'name': instance.name,
      'parentSystemId': const GuidConverter().toJson(instance.parentSystemId),
      'averageDistanceToCenter': instance.averageDistanceToCenter,
      'rotationSpeed': instance.rotationSpeed,
      'averageTemperature': instance.averageTemperature,
      'assetName': instance.assetName,
      'coordinates': instance.coordinates,
      'starType': _$StarTypeEnumMap[instance.starType],
      'scale': instance.scale,
      'axialTilt': instance.axialTilt,
      'resources': instance.resources,
      'order': instance.order,
    };

K _$enumDecode<K, V>(
  Map<K, V> enumValues,
  Object? source, {
  K? unknownValue,
}) {
  if (source == null) {
    throw ArgumentError(
      'A value must be provided. Supported values: '
      '${enumValues.values.join(', ')}',
    );
  }

  return enumValues.entries.singleWhere(
    (e) => e.value == source,
    orElse: () {
      if (unknownValue == null) {
        throw ArgumentError(
          '`$source` is not one of the supported values: '
          '${enumValues.values.join(', ')}',
        );
      }
      return MapEntry(unknownValue, enumValues.values.first);
    },
  ).key;
}

const _$StarTypeEnumMap = {
  StarType.brownDwarf: 0,
  StarType.yellowDwarf: 1,
  StarType.whiteStar: 2,
  StarType.redGiant: 3,
  StarType.blueGiant: 4,
};
